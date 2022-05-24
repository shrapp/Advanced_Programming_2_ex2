import { GetChat, GetNickName, GetPhoto } from '../../data/users';
import ContactItem from './ContactItem'
import React from "react";
import '../chatbox/formatTime'
import { formatDateTime } from "../formatDateTime";

function ContactsListResault({ user, toShow, setDisplayedContact }) {
    const contactsListDisp = toShow.map((contact, key) => {
        const photo = GetPhoto(contact);
        return <ContactItem 
            id={contact.id}
            name={contact.name}
            time={formatDateTime(new Date(contact.lastdate))} 
            lastMessage={contact.last} 
            photo={photo}
            setDisplayedContact={setDisplayedContact} 
            key={key} />}
    );

    return(
        <div className='contacts_list'> {contactsListDisp} </div>
    );
}

export default ContactsListResault;