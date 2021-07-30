import React, {useState} from "react";
import FormInput from "../UI/FormInput";
import Paragrafo from "../UI/Paragrafo";
import Botao from "../UI/Botao";
import fetchApiAsync from "../../common/fetchApiAsync"
import Swal from "sweetalert2";

export default function Register({history}) {

   const onRegister = async (event) => {
      event.preventDefault();

      const route = "/api/account/register";
      const method = "POST";

      const response = await fetchApiAsync({route, data: formRegister, method})


      const responseContent = await response.json();
  
      if(!response.ok)
      {  
         Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: `${responseContent[0]}`,
          })
         return;
      }

      Swal.fire({
         icon: 'success',
         title: 'Welcome!',
         text: `Ready to organize all your activities? Let's start adding your first one!`,
       })

      history.push("/");

      localStorage.setItem("token", responseContent);
   }

   const [formRegister, setFormRegister] = useState({email: '', password: '', confirmPassword: ''});
   
   const setEmail = (event) => {
      setFormRegister({...formRegister, email: event.target.value})
   }

   const setPassword = (event) => {
      setFormRegister({...formRegister, password: event.target.value})
   }

   const setConfirmPassword = (event) => {
      setFormRegister({...formRegister, confirmPassword: event.target.value})
   }
   
   const onVoltar = () => {
      history.push("/login");
   }

   return (
      <div className="form-content" style={{width: '450px'}}>
         <Paragrafo>Crie uma conta no <strong>Sunday.com</strong>.</Paragrafo>
         <form>

            <FormInput 
            id="email" 
            type="email" 
            placeholder="E-mail" 
            label="E-mail"
            value={formRegister.email}
            onChange={setEmail} 
            />

            <FormInput 
            id="senha" 
            type="password" 
            placeholder="Senha" 
            label="Senha"
            value={formRegister.password}
            onChange={setPassword} 
            />

            <FormInput 
            id="confirm-password" 
            type="password" 
            placeholder="Confirmar a Senha" 
            label="Confirmar a Senha"
            value={formRegister.confirmPassword}
            onChange={setConfirmPassword} 
            />

            <Botao text="Registrar" className="btn btn-purple" type="submit" onClick={onRegister}/>
            <Botao text="Voltar" className="btn btn-red" onClick={onVoltar}/>

         </form>
      </div>
   );
}