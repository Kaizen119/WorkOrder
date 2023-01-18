import React, { useState } from 'react';

const ModalController = (ModalContent) => {
    const [isVisible, setIsVisible] = useState(false);

    const toggleModal = () => {
        setIsVisible(!isVisible);
    }

    return (
    <div>
        <button onClick={toggleModal}>Open Modal</button>
        {isVisible && <ModalContent title="Modal Title" message="Modal message" />}
    </div>
    );
}

export default ModalController;