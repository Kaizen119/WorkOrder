import React from 'react'
import axios from 'axios'
import { useParams, useNavigate } from 'react-router-dom'
import { useState, useEffect } from 'react';
import { Button } from 'react-bootstrap';
import 'bootstrap/dist/js/bootstrap.bundle.min';



const Dashboard = (props) => {
    // const navigate = useNavigate()

    const [workOrder, setWorkOrder] = useState([])
    const [status, setStatus] = useState("open")
    
    useEffect(()=>{
        axios.get(`http://localhost:5044/api/WorkOrder/GetAll/${status}`)
        .then(response => {
            console.log(response.data)
            setWorkOrder(response.data)
        })
        .catch(error => {
            console.log(error)
        })
    },[status]);

    const handleStatusChange = (status) => {
        if(status === "Closed"){
            setStatus("Closed")
        }
        else{
            setStatus("Open")
        }
        };
    
    return (
    <div className="mx-auto" style={{backgroundColor: '#5A5A5A', height: '100vh', width: '100vw'}}>
        <div className="container" style={{color: 'white', padding: '20px', width:'100%'}}>
            <div className="mt-4">
                <div class="dropdown">
                    <Button class="btn btn-primary dropdown-toggle" type="button" id="dropdownMenuButton" data-bs-toggle="dropdown" aria-expanded="false" style={{backgroundColor: '#357EC7', color:'#f2ede6'}}>
                    Work Order Status:
                    </Button>
                    <div class="dropdown-menu" aria-labelledby="dropdownMenuButton" >
                        <a className="dropdown-item" onClick={() => handleStatusChange('Open')}>Open</a>
                        <a className="dropdown-item" onClick={() => handleStatusChange('Closed')}>Closed</a>
                    </div>
                </div>
                <table className="table table-bordered" style={{borderColor:'#357EC7',fontSize:'18px', color: '#f2ede6', padding: '20px'}}>
                    <thead>
                        <tr>
                            <th scope="col">Work Order #</th>
                            <th scope="col">Email</th>
                            <th scope="col">Status</th>
                            <th scope="col">Date Recived</th>
                            <th scope="col">Date Assigned</th>
                            <th scope="col">Date Complete</th>
                            <th scope="col">Contact Name</th>
                            <th scope="col">Technician Comments</th>
                            <th scope="col">Contact Number</th>
                            <th scope="col">Problem</th>
                            <th scope="col">Technician Id</th>
                            
                        </tr>
                    </thead>
                    <tbody>
                    {
                    workOrder.map((oneWorkOrder) => {
                        return(
                        <tr key= {oneWorkOrder.woNum}>
                            <th scope="row">{oneWorkOrder.woNum}</th>
                            <td>{oneWorkOrder.email}</td>
                            <td>{oneWorkOrder.status}</td>
                            <td>{oneWorkOrder.dateReceived}</td>
                            <td>{oneWorkOrder.dateAssigned}</td>
                            <td>{oneWorkOrder.dateComplete}</td>
                            <td>{oneWorkOrder.contactName}</td>
                            <td>{oneWorkOrder.technicianComments}</td>
                            <td>{oneWorkOrder.contactNumber}</td>
                            <td>{oneWorkOrder.problem}</td>
                            <td>{oneWorkOrder.technician}</td>
                        </tr>
                        )
                        })
                    }
                    </tbody>
                </table>
            </div>
        </div>        
    </div>
    )
}

export default Dashboard