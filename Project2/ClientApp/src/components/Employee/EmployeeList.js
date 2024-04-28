// src/components/EmployeeList/EmployeeList.js
import React, { useState, useEffect } from 'react';
import EmployeeListItem from './EmployeeListItem';
import authService from '../api-authorization/AuthorizeService';

import employeeService from '../services/employeeService';

const EmployeeList = () => {
  const [employees, setEmployees] = useState([]);

  useEffect(() => {
    fetchEmployees();
  }, []);

  const fetchEmployees = async () => {
    try {
      //const employeesData = await employeeService.getAllEmployees();
      const token = await authService.getAccessToken();
      const path = 'https://localhost:7163/employee';
      const response = await fetch(path, {
        headers: !token ? {} : {
          'Content-Type': 'application/json', 'Accept': 'application/json', 'Authorization': `Bearer ${token}`,
          'Origin' : 'http://localhost:44490'
        }
      });
      const employeesData = await response.json();
      setEmployees(employeesData);

    } catch (error) {
      console.error('Error fetching employees:', error);
    }
  };

  const handleDelete = async (id) => {
    try {
      await employeeService.deleteEmployee(id);
      fetchEmployees(); // Refresh employee list
    } catch (error) {
      console.error('Error deleting employee:', error);
    }
  };

  const handleEdit = () => {
    fetchEmployees(); // Refresh employee list after editing
  };

  return (
      <div>
          <div className="data-table-heading pt-2 pb-2">
              <h2 className="">Employee List</h2>
              <button class="btn btn-primary" type="button" data-bs-toggle="offcanvas" data-bs-target="#staticBackdrop" aria-controls="staticBackdrop">
                  Toggle static offcanvas
              </button>
          </div>
      <hr />
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Employee ID</th>
            <th>Firstname</th>
            <th>Lastmame</th>
            <th>Email Address</th>
            <th>Phone Number</th>
            <th>Job Title</th>
            <th>Active</th>
            <th>Date Added</th>
          </tr>
        </thead>
        <tbody>
          {employees.map(employee => (
            <EmployeeListItem key={employee.employeeId} employee={employee} onDelete={() => handleDelete(employee.employeeId)} onEdit={() => handleEdit()} />
          ))}          
        </tbody>
      </table>
          

          <div class="offcanvas offcanvas-start" data-bs-backdrop="static" tabindex="-1" id="staticBackdrop" aria-labelledby="staticBackdropLabel">
              <div class="offcanvas-header">
                  <h5 class="offcanvas-title" id="staticBackdropLabel">Offcanvas</h5>
                  <button type="button" class="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
              </div>
              <div class="offcanvas-body">
                  <div>
                      I will not close if you click outside of me.
                  </div>
              </div>
          </div>
    </div>
  );
};

export default EmployeeList;