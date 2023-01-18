import React from 'react';

const ModalContent = (props) => {
    return (
        <div>
            <h1>{props.title}</h1>
            <p>{props.message}</p>
        </div>
    )
}

export default ModalContent;