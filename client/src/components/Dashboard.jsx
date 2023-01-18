import React from 'react'
import axios from 'axios'
import { useState, useEffect } from 'react';
import { Button } from 'react-bootstrap';
import 'bootstrap/dist/js/bootstrap.bundle.min';
import Modal from 'react-modal';

const Dashboard = (props) => {

//state variables
    const [workOrder, setWorkOrder] = useState([]);
    const [status, setStatus] = useState("open");
    const [fetchedTechnician, setFetchedTechnician] = useState([]);
    const [isOpen,setIsOpen] = React.useState(false);

//forms submit variables 
    const [email, setEmail] = useState("")
    const [contactName, setContactName,] = useState("")
    const [contactNumber, setContactNumber] = useState("")
    const [problem, setProblem] = useState("")
    const [technicianID, setTechnicianID] = useState("")


// pulls all work orders by status to be displayed
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

// pulls all techs in the DB for use in the modal form
    useEffect(()=>{
        if(isOpen){
        axios.get(`http://localhost:5044/api/Technician/GetAll`)
        .then(response => {
            console.log(response.data.data)
            setFetchedTechnician(response.data.data)
        })
        .catch(error => {
            console.log(error)
        })}
    },[isOpen]);

// logic for handling the status changes for the table
    const handleStatusChange = (status) => {
        if(status === "Closed"){
            setStatus("Closed")
        }
        else if (status === "Assigned"){
            setStatus("Assigned")
        }
        else{
            setStatus("Open")
        }
    };

// creating the work order
    const createWorkOrder = (e) => {
        // e.preventDefault();
        const tempObjToSendToDB = {
            email,
            status,
            contactName,
            contactNumber,
            problem,
            technicianID
        }
        console.log(tempObjToSendToDB)
        axios.post('http://localhost:5044/api/WorkOrder', tempObjToSendToDB)
        .then(response => {
            console.log("Client Success")
            console.log(response.data)
        })
        .catch(error => {
            console.log("Something Went Wrong")
            console.log(error)
        }) 
    }

// function to open/close the modal
    function openModal() {
        setIsOpen(true);
    }
    function closeModal(){
        setIsOpen(false);
    };
    
    return (
    <div className="mx-auto" style={{backgroundColor: '#5A5A5A', height: '100vh', width: '100vw'}}>
        <div className="container-" style={{backgroundColor: '#5A5A5A', color: 'white', padding: '20px', width:'100%'}}>
            <div className="mt-4">
                <div className="dropdown">

{/* button and logic for switching between the WorkOrder status to be displayed by the table */}
                    <Button className="btn btn-primary dropdown-toggle" type="button" id="dropdownMenuButton" data-bs-toggle="dropdown" aria-expanded="false" style={{backgroundColor: '#357EC7', color:'#f2ede6'}}>
                    Work Order Status:
                    </Button>
                    <div className="dropdown-menu" aria-labelledby="dropdownMenuButton" >
                        <a className="dropdown-item" onClick={() => handleStatusChange('Open')}>Open</a>
                        <a className="dropdown-item" onClick={() => handleStatusChange('Assigned')}>Assigned</a>
                        <a className="dropdown-item" onClick={() => handleStatusChange('Closed')}>Closed</a>
                    </div>
                </div>

{/* table for displaying the work orders  */}
                <table className="table table-bordered mt-3" style={{borderColor:'#357EC7',fontSize:'18px', color: '#f2ede6', padding: '20px'}}>
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
                            <td>{oneWorkOrder.technicianID}</td>
                        </tr>
                        )
                        })
                    }
                    </tbody>
                </table>
                <div>

{/* create WorkOrder button and logic for the modal  */}
                    <Button style={{borderColor:'#357EC7',fontSize:'18px', color: '#f2ede6', width: '35%'}} onClick={openModal}>Create New Work Order</Button>
                    <Modal style={{content: {position: 'fixed',top: '45%',left: '45%',transform: 'translate(-45%, -45%)', backgroundColor: '#5A5A5A', color:'#f2ede6'}}} isOpen={isOpen}onRequestClose={closeModal}>

{/* form for WorkOrder sub */}
                        <form onSubmit={createWorkOrder}>
                        
                        <label htmlFor="formControlInput" className="form-label">Email address</label>
                        <input type="email" className="form-control" id="formControlInput" placeholder="name@lakecountyfl.gov.com" onChange={(e) => setEmail(e.target.value)} value={email}/>
                        
                        <label htmlFor="formControlInput" className="form-label">Contact Name</label>
                        <input type="text" className="form-control" id="formControlInput" placeholder="Your Name Here" onChange={(e) => setContactName(e.target.value)} value={contactName}/>
                        
                        <label htmlFor="formControlInput" className="form-label">Contact Number</label>
                        <input type="text" className="form-control" id="formControlInput" placeholder="352-343-9420" onChange={(e) => setContactNumber(e.target.value)} value={contactNumber}/>
                        
                        <label htmlFor="formControlInput" className="form-label">Problem</label>
                        <input type="text" className="form-control" id="formControlInput" placeholder="Please describe your current situation" onChange={(e) => setProblem(e.target.value)} value={problem}/>
                        
                        <label htmlFor="formControlInput" className="form-label">Technician</label>
{/* dropdown menu for tech */}
                        <div>
                        <select className="form-select" aria-label="Default select" onChange={(e) => setTechnicianID(e.target.value)} >
                        <option >Choose Technician</option>
                        {
                        fetchedTechnician.map((oneTechnician) => {
                            return(
                        <option   key={oneTechnician.technicianID} value= {oneTechnician.technicianID}
                        >{oneTechnician.technicianName}</option>)})}
                        </select>
                        </div>

{/* button that submits the form */}
                        <button type="submit" className="btn btn-success">Submit</button>
                        </form>

{/* button that closes the modal */}
                        <button  style={{backgroundColor: '#357EC7', color:'#f2ede6'}} onClick={closeModal}>close</button>
                    </Modal>
                </div>
            </div>
        </div>        
    </div>
    )
}

export default Dashboard