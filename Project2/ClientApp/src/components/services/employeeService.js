import axios from 'axios';

const baseURL = 'https://localhost:7163/api/Employee';

const employeeService = {
  getAllEmployees: async () => {
    const response = await axios.get(baseURL);
    return response.data;
  },
  addEmployee: async (employee) => {
    const response = await axios.post(baseURL, employee);
    return response.data;
  },
  deleteEmployee: async (id) => {
    const response = await axios.delete(`${baseURL}/${id}`);
    return response.data;
  },
  updateEmployee: async (id, employee) => {
    const response = await axios.put(`${baseURL}/${id}`, employee);
    return response.data;
  }
};

export default employeeService;