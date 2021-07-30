export default function FormInput({id, type, placeholder, label, value, onChange}) { 
    return (
       <>
          <label htmlFor={id}>{label}</label>
          <input 
          id={id}
          type={type} 
          placeholder={placeholder}
          value={value} 
          onChange={onChange} 
          />
       </>
    );
}