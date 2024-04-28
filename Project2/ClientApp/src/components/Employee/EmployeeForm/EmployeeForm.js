// src/components/EmployeeForm/EmployeeForm.js
import React, { useState } from 'react';
import employeeService from '../../services/employeeService';
import authService from '../../api-authorization/AuthorizeService';


export const EmployeeForm = ({ onEmployeeAdded }) => {
  const [employeeId, setEmployeeId] = useState('');
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [emailAddress, setEmailAddress] = useState('');
  const [jobTitle, setJobTitle] = useState('');
  const [active, setActive] = useState('');
  const [phoneNumber, setPhoneNumber] = useState('');

  const handleSubmit = async (event) => {
      event.preventDefault();
      let today = new Date().toJSON();
    const newEmployee = { employeeId, firstName, lastName, emailAddress, jobTitle, active, dateAdded: today , phoneNumber };
    try {
      //await employeeService.addEmployee(newEmployee);
      const token = await authService.getAccessToken();
      const path = 'https://localhost:7163/employee';
      const response = await fetch(path, {
        method: "POST",
        headers: !token ? {} : {
          'Content-Type': 'application/json', 'Accept': 'application/json', 'Authorization': `Bearer ${token}`,
          'Origin': 'http://localhost:44490'
        },
        body: JSON.stringify(newEmployee)
      });
      const result = await response.json();
      console.log("Success:", result);
      
      setEmployeeId('');
      setFirstName('');
      setLastName('');
      setEmailAddress('');
      setJobTitle('');
      setPhoneNumber('');
      setActive('');
      alert("Employee Sucessfully Created!");
      

    } catch (error) {
      console.error('Error adding employee:', error);
    }
    
  };

  return (
    <div className="container">
      <h2 className="my-4">Add Employee</h2>
      <div class="row g-5">

        <div class="col-3">
          
        </div>

        <div class="col-6">
          <form class="needs-validation" novalidate="" onSubmit={handleSubmit}>
            <div class="row g-3">
              <div className="col-12 pl-5">
                <label for="employeeId" class="form-label">Employee ID</label>
                <input type="text" class="form-control" id="employeeId" value={employeeId} onChange={e => setEmployeeId(e.target.value)} required="" />
                <div class="invalid-feedback">
                  Valid Employee ID is required.
                </div>
              </div>

              

              <div class="col-sm-6">
                <label for="firstName" class="form-label">First Name</label>
                <input type="text" class="form-control" id="firstName" value={firstName} onChange={e => setFirstName(e.target.value)} required="" />
                  <div class="invalid-feedback">
                    Valid first name is required.
                  </div>
              </div>

              <div class="col-sm-6">
                <label for="lastName" class="form-label">Last Name</label>
                <input type="text" class="form-control" id="lastName" value={lastName} onChange={e => setLastName(e.target.value)} required="" />
                  <div class="invalid-feedback">
                    Valid last name is required.
                  </div>
              </div>

              <div className="col-8">
                <label for="emailAddress" class="form-label">Email Address</label>
                <input type="text" class="form-control" id="emailAddress" placeholder="" value={emailAddress} onChange={e => setEmailAddress(e.target.value)} required="" />
                <div class="invalid-feedback">
                  Valid email address is required.
                </div>
              </div>

              <div className="col-4">
                <label for="phoneNumber" class="form-label">Phone Number</label>
                <input type="text" class="form-control" id="phoneNumber" placeholder="" value={phoneNumber} onChange={e => setPhoneNumber(e.target.value)} required="" />
                <div class="invalid-feedback">
                  Valid phone number is required.
                </div>
              </div>

              <div class="col-5">
                <label for="jobTitle" class="form-label">Job Title</label>
                <input type="text" class="form-control" id="jobTitle" placeholder="" value={jobTitle} onChange={e => setJobTitle(e.target.value)} />
                  <div class="invalid-feedback">
                    Please enter a valid job title.
                  </div>
              </div>            

              <hr class="my-4" />

              <h4 class="mb-3">Active Employee</h4>

              <div class="my-3">
                <div class="form-check form-check-inline">
                  <input id="active" name="active" type="radio" class="form-check-input"  onChange={e => setActive(true)} />
                    <label class="form-check-label" for="active">Active</label>
                </div>
                <div class="form-check form-check-inline">
                  <input id="inactive" name="active" type="radio" value="false" onChange={e => setActive(false)} class="form-check-input" required="" />
                    <label class="form-check-label" for="inactive">Inactive</label>
                </div>
              </div>

              <hr class="my-4" />


              <button class="w-100 btn btn-primary btn-lg" type="submit">Create New Employee</button>
            </div>
          </form>
        </div>

        <div className="col-3">

        </div>

      </div> 
    </div>

  );
};

