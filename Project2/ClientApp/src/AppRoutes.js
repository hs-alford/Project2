import ApiAuthorzationRoutes from './components/api-authorization/ApiAuthorizationRoutes';
import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import  EmployeeList from "./components/Employee/EmployeeList";
import { Home } from "./components/Home";
import { EmployeeForm } from './components/Employee/EmployeeForm/EmployeeForm';

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    requireAuth: true,
    element: <FetchData />
  },
  {
    path: '/employee-list',
    requireAuth: true,
    element: <EmployeeList />
  },
  {
    path: '/add-employee',
    requireAuth: true,
    element: <EmployeeForm />
  },

  ...ApiAuthorzationRoutes
];

export default AppRoutes;
