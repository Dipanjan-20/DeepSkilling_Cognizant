import Styles from './EmployeeCard.module.css';
import ThemeContext from './ThemeContext';
import { useContext } from 'react';

function EmployeeCard(props) {
  const theme = useContext(ThemeContext);

  return (
    <div className={Styles.Card}>
      <h3>{props.employee.name}</h3>
      <p>{props.employee.email}</p>
      <p>{props.employee.phone}</p>
      <p>
        <a href="www.google.com" className={theme}>Edit</a>
        <a href="www.google.com" className={theme}>Delete</a>
      </p>
    </div>
  );
}

export default EmployeeCard;
