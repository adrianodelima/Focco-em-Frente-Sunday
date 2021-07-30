import React, {useState} from "react";
import Botao from '../UI/Botao'
import Paragrafo from '../UI/Paragrafo'
import FormInput from '../UI/FormInput'
import fetchApiAsync from '../../common/fetchApiAsync'
import Swal from "sweetalert2";

export default function Login({history}) {

   const [formLogin, setFormLogin] = useState({email: '', password: ''});

      
   const setEmail = (event) => {
      setFormLogin({...formLogin, email: event.target.value})
   }

   const setPassword = (event) => {
      setFormLogin({...formLogin, password: event.target.value})
   }

   const onRegister = () => {
      history.push('/register');
   }

   const onLogin = async (event) => {
      event.preventDefault();

      const route = "/api/account/login";
      const method = "POST";
      
      const response = await fetchApiAsync({route, data: formLogin, method})

      const responseContent = await response.json();

      if(!response.ok)
      {  
         Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: "Wrong email or password!"
          })
         return;
      }

         Swal.fire({
            icon: 'success',
            title: 'Welcome!',
            text: `Finally, you're back! I knew you had a pending activity!`,
          })

      localStorage.setItem("token", responseContent);
      history.push("/");
   }

   return (
      <div className="form-content">
         <Paragrafo>Bem-vindo ao <strong>Sunday.com</strong>, o melhor sistema para gestão de tarefas.</Paragrafo>
         <form>
            <FormInput 
            id="email" 
            type="email" 
            placeholder="E-mail" 
            label="E-mail"
            value={formLogin.email} 
            onChange={setEmail} 
            />

            <FormInput id="password" 
            type="password" 
            placeholder="Informe sua senha" 
            label="Senha"
            value={formLogin.password} 
            onChange={setPassword} 
            />

            <Botao className="btn btn-purple" text="Entrar" submit onClick={onLogin}/>
            <Botao className="btn btn-green" text="Registrar" type="secondary" onClick={onRegister}/>
         </form>
      </div>
   );
}