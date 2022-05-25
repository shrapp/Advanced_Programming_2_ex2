import React, { useState, useEffect } from 'react';
import ContactsBar from './contacts/ContactsBar';
import ChatBox from './chatbox/ChatBox'
import { GetChat, GetContacts } from '../data/users'

function UserApp({ user }) {

    // add here a use State (maybe with ref) for updating user.
    const [did_data_change, set_did_data_change] = useState(false);
    //useEffect(() => {
    //    getContacts();
    //}, [did_data_change])

    // this useState updates the contact that should be showd in the chat box
    const [displayedContact, setDisplayedContact] = useState(null);

    const [chat, setChat] = useState(null);

    const [contacts, setContacts] = useState(null);

    const changeDisplayedContact = async function (contact) {
        let mychat = await GetChat(user, contact)
        setChat(mychat);
        setDisplayedContact(contact);
    }

    const setDataChanged = async function (c) {
        if (displayedContact != null)
            await changeDisplayedContact(displayedContact);
        let myContacts = await GetContacts(user);
        setContacts(myContacts);
        set_did_data_change(!did_data_change);
    }

    return (
        <div className="user_app">
            <ContactsBar user={user} contacts={contacts}
                setDisplayedContact={changeDisplayedContact} setDataChanged={setDataChanged} />
            <ChatBox contact={displayedContact} user={user} chat={chat}
                did_data_change={did_data_change} set_did_data_change={setDataChanged} />
        </div>
    );
}

export default UserApp;