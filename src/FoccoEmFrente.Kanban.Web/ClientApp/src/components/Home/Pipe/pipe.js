import React from "react"
import Activity from "../Activity"

export default function Pipe({activities, status, onDelete, onUpdate, onActivityDrops}){
  const activitiesList = activities && activities.filter((activity) => activity.status === status);

  const onDeleteActivity = (activity) => {
    if(onDelete){
      onDelete(activity);
    }
  }
  
  const onUpdateActivity = (activity) => {
    if(onUpdate){
      onUpdate(activity);
    }
  }

  const onDragActivityOver = (event) => {
    event.preventDefault();
  }

  const onDropActivity = (event) => {
    const activityId = event.dataTransfer.getData("activityId");

    if(activityId && onActivityDrops){
      onActivityDrops(activityId);
    }
  }

  const title = 
      status === "Todo"
        ? "Aguardando"
        : status === "Doing"
        ? "Em andamento"
        :"Concluído"

  return (
    <div className={`pipe pipe-${status}`} onDragOver={onDragActivityOver} onDrop={onDropActivity}>

      <span className='pipe-title'>
        {title} / {activitiesList.length}
      </span>

      {activitiesList.map((activity, index) => {
        return <Activity 
        onDelete={onDeleteActivity}
        onUpdate={onUpdateActivity} 
        activity={activity} 
        key={index}/>
      })}

    </div>
  );

}