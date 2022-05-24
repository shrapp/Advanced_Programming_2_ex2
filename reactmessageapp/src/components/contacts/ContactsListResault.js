import ContactItem from './ContactItem'
import React from "react";
import '../chatbox/formatTime'

function ContactsListResault({ toShow, setDisplayedContact }) {
    const contactsListDisp = toShow.map((contact, key) => {
        return <ContactItem
            Contact={contact}
            setDisplayedContact={setDisplayedContact} 
            key={key} />}
    );

    return(
        <div className='contacts_list'> {contactsListDisp} </div>
    );
}

export default ContactsListResault;