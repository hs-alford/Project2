// src/components/EmployeeList/EmployeeListItem.js
import React, { useState } from 'react';
import employeeService from '../services/employeeService';
import authService from '../api-authorization/AuthorizeService';


const EmployeeListItem = ({ employee, onDelete, onEdit }) => {
  const [isEditing, setIsEditing] = useState(false);
  const [employeeId, setEmployeeId] = useState(employee.employeeId);
  const [editedFirstName, setEditedFirstName] = useState(employee.firstName);
  const [editedLastName, setEditedLastName] = useState(employee.lastName);
  const [editedEmailAddress, setEditedEmailAddress] = useState(employee.emailAddress);
  const [editedPhoneNumber, setEditedPhoneNumber] = useState(employee.phoneNumber);
  const [editedJobTitle, setEditedJobTitle] = useState(employee.jobTitle);
  const [editedActive, setEditedActive] = useState(employee.active);
  const [dateAdded, setDateAdded] = useState(employee.dateAdded);

  const handleEdit = async () => {
    setIsEditing(true);
  };

  const handleSave = async () => {
    const editedEmployee = {
      ...employee, employeeId: employeeId, firstName: editedFirstName, lastName: editedLastName, emailAddress: editedEmailAddress,
      phoneNumber: editedPhoneNumber, jobTitle: editedJobTitle, active: editedActive, dateAdded: dateAdded
    };
    try {
      const token = await authService.getAccessToken();
      const path = 'https://localhost:7163/employee/' + employeeId;
      const response = await fetch(path, {
        method: "PUT",
        headers: !token ? {} : {
          'Content-Type': 'application/json', 'Accept': 'application/json', 'Authorization': `Bearer ${token}`,
          'Origin': 'http://localhost:44490'
        },
        body: JSON.stringify(editedEmployee)
      });
      //const result = await response.json();
        //console.log("Success:", result);
        
        setIsEditing(false);
        handleRefresh(); // Refresh employee list
    } catch (error) {
      console.error('Error updating employee:', error);
    }
  };

    const handleRefresh = () => {
        onEdit()
    };
  const handleCancel = () => {
    setIsEditing(false);
    // Reset edited values
    setEditedFirstName(employee.firstName);
    setEditedLastName(employee.lastName);
    setEditedEmailAddress(employee.emailAddress);
    setEditedPhoneNumber(employee.phoneNumber);
    setEditedJobTitle(employee.jobTitle);
    };


  return (

    <>
      {isEditing ? (
        <tr>
          <td>
            <input type="text" className="form-control" value={employeeId} disabled />
          </td>
          <td><input type="text" className="form-control" value={editedFirstName} onChange={e => setEditedFirstName(e.target.value)} required /></td>
          <td><input type="text" className="form-control" value={editedLastName} onChange={e => setEditedLastName(e.target.value)} required /></td>
          <td><input type="text" className="form-control" value={editedEmailAddress} onChange={e => setEditedEmailAddress(e.target.value)} required /></td>
          <td><input type="text" className="form-control" value={editedPhoneNumber} onChange={e => setEditedPhoneNumber(e.target.value)} required /></td>
          <td><input type="text" className="form-control" value={editedJobTitle} onChange={e => setEditedJobTitle(e.target.value)} required /></td>
          <td>
            <div class="form-check form-check-inline">
              <input id="active" name="active" type="radio" class="form-check-input" onChange={e => setEditedActive(true)} />
              <label class="form-check-label" for="active">Active</label>
            </div>
            <div class="form-check form-check-inline">
              <input id="inactive" name="active" type="radio" value="false" onChange={e => setEditedActive(false)} class="form-check-input" required="" />
              <label class="form-check-label" for="inactive">Inactive</label>
            </div>
          </td>
          <td><input type="text" className="form-control" value={dateAdded} disabled /></td>
          <td>
            <button className="btn btn-success me-2" onClick={handleSave}>Save</button>
            <button className="btn btn-secondary" onClick={handleCancel}>Cancel</button>
          </td>
        </tr>
       
      ) : (
          <tr>
            <td>{employee.employeeId}</td>
            <td>{employee.firstName}</td>
            <td>{employee.lastName}</td>
            <td>{employee.emailAddress}</td>
            <td>{employee.phoneNumber}</td>
            <td>{employee.jobTitle}</td>
            <td>{employee.active ? 'Active' : 'Inactive'}</td>
            <td>{employee.dateAdded.split('T')[0]}</td>
            <td>
              <button className="btn btn-danger me-2" onClick={onDelete}>Delete</button>
              <button className="btn btn-primary" onClick={handleEdit}>Edit</button>
            </td>
        </tr>
         
      )}
    </>
  );
};

export default EmployeeListItem;