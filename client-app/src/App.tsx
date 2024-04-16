import { useEffect, useState } from 'react'
import axios from 'axios';

import './App.css'

function App() {

  const [activities, setActivities] = useState([])
  let [tru, setTru] =useState(false)

  
  useEffect(() => {
    axios.get('http://localhost:5000/api/activities').then((response: any) => {
      setActivities(response.data)
      console.log(response.data)
    })
}, []);

  return (
    <>
  
    {activities.map(( el: any ) => (
      <div key={el.id}>
        <p>{el.title}</p>
      </div>
    ))}
    </>
  )
} 

export default App
