import React from "react";
import Logo from '../../assets/logo.png'

export default function Layout(props) {
   return ( 
      <div className="form-container">  
         <div className="content">

            <div className="logo-container">
               <img src={Logo} alt="Sunday"/>
            </div>
            
            {props.children}

         </div>
      </div>
   )
}
