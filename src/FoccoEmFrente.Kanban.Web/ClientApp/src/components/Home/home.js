import React, {useState, useEffect} from "react";
import Botao from "../UI/Botao"
import Pipe from "./Pipe";
import "./home.css"
import fetchApiAsync from "../../common/fetchApiAsync"
import Swal from "sweetalert2";

export default function Home({history}){
   const [activities, setActivities] = useState([]);

   const loadActivities = async () => {

      const route = "/api/activities";
      const method = "GET";
      const token = localStorage.getItem("token");

      const response = await fetchApiAsync({route, method, history, auth: token})

      const responseContent = await response.json();
      
      if(!response.ok)
      {  
         Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: `${responseContent}!`,
          })
         return;
      }
      setActivities(responseContent);
   }

   const addActivity = async () => {
      const newActivity = {
         title: "Nova Atividade",
         status: "Todo"
      }

      const route = "/api/activities";
      const method = "POST";
      const token = localStorage.getItem("token");

      const response = await fetchApiAsync({route, data: newActivity, method, auth: token });
      const responseContent = await response.json();
      
      if(!response.ok){
       
            Swal.fire({
               icon: 'error',
               title: 'Oops...',
               text: `${responseContent[0]}!`,
             })
            return;
         
      }
      setActivities([...activities, responseContent])
   }
   
   const updateActivity = async (activity) => {
      const route = `/api/activities`;
      const method = "PUT";
      const token = localStorage.getItem("token");
      
      const response = await fetchApiAsync({route, data: activity, method, auth: token });
      const responseContent = await response.json();
      
      if(!response.ok){
       
            Swal.fire({
               icon: 'error',
               title: 'Oops...',
               text: `${responseContent[0]}!`,
             })
            return;
         
      }
      await loadActivities();
      return;
   }

   const updateActivityStatus = async (activityId, status) => {

      const route = `/api/activities/${activityId}/${status}`;
      const method = "PUT";
      const token = localStorage.getItem("token");

      const response = await fetchApiAsync({route, method, auth: token });
      const responseContent = await response.json();

      if(!response.ok){
         Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: `${responseContent[0]}!`,
          })
         return;
   }
      await loadActivities();
   }

   
   const deleteActivity = async (activity) => {
      const route = `/api/activities/${activity.id}`;
      const method = "DELETE";
      const token = localStorage.getItem("token")

      const response = await fetchApiAsync({route, data: activity, method, auth: token });
      const responseContent = await response.json();
      
      if(!response.ok){
       
            Swal.fire({
               icon: 'error',
               title: 'Oops...',
               text: `${responseContent[0]}!`,
             })
            return;
         
      }
      setActivities(activities.filter(a => a.id !== activity.id));
   }

   const onExit = () => {
      localStorage.removeItem("token");
      history.push("/login");
   }

   useEffect(() => {
      async function fetchData() {
         await loadActivities();
      }
      fetchData();
    }, []);
    

   useEffect(()=> {
      async function fetchData(){
         await loadActivities()
      } 
      fetchData();
   }
   , []);

   return (
      <div className="home-content">
         <p>
            Bem vindo ao <strong>Sunday.com</strong>
         </p>
         <p>
            Esse é seu canvas para organizar suas atividades. 
            Crie novas atividades e mantenha elas sempre atualizadas.
         </p>

         <div className="canvas">
            {
               ["Todo", "Doing", "Done"].map((status, index) => {
                  return (
                  <Pipe 
                  key={index} 
                  activities={activities} 
                  status={status} 
                  onDelete={deleteActivity}
                  onUpdate={updateActivity}
                  onActivityDrops={(activityId) => updateActivityStatus(activityId, status)}
                  />
               );
            }) 
         }
         </div>

         <Botao text="Adicionar atividade" className="btn btn-purple" onClick={addActivity} type="submit"></Botao>
         <Botao text="Sair" className="btn btn-red" onClick={onExit}></Botao>
      </div>
   );
}