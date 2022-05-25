import A_photo from './pink_flower_2.jpeg'
import B_photo from './flowers_square.jpeg'
import Shahar_photo from './shahar_profile.jpg'
import Me_photo from './prof_img.jpeg'
import beit_hmikdash from './first_mikdash.jpg'
import bait_sheni from './second_mikdash.jpg'
import crown_img from './crown.jpg'
import snowVideo from './snowVideo.mp4'
import pdfFile from './ex1PdfFile.pdf'
import record from './record1.ogg'

import contact from './blank_contact.jpg'


const users = {};
users['aaa'] = {nickName: 'Abba Even with a very long name', password: 'Apass', photo: A_photo,
    contacts: {
        'bbb': [
            {sender: true, time: '7:32 10.4.22', type: 'text', content: 'hi its my 1\'st message'},
            {sender: false, time: '7:34 10.4.22', type: 'text', content: 'The early history of the territory is unclear.[26]: 104  Modern archaeology has largely discarded the historicity of the narrative in the Torah concerning the patriarchs, The Exodus, and the conquest of Canaan described in the Book of Joshua, and instead views the narrative as constituting the Israelites\' national myth.[69] During the Late Bronze Age (1550–1200 BCE), large parts of Canaan formed vassal states paying tribute to the New Kingdom of Egypt, whose administrative headquarters lay in Gaza.[70]'},
            {sender: true, time: '7:37 10.4.22', type: 'text', content: 'hi its my 2\'st message'}
            ]
        }
    }
users['bbb'] = {nickName: 'Bracha Achronah', password: 'Bpass', photo: B_photo,
    contacts: {
        'aaa': [
            {sender: false, time: '7:32 10.4.22', type: 'text', content: 'hi its my 1\'st message'},
            {sender: true, time: '7:34 10.4.22', type: 'text', content: 'The early history of the territory is unclear.[26]: 104  Modern archaeology has largely discarded the historicity of the narrative in the Torah concerning the patriarchs, The Exodus, and the conquest of Canaan described in the Book of Joshua, and instead views the narrative as constituting the Israelites\' national myth.[69] During the Late Bronze Age (1550–1200 BCE), large parts of Canaan formed vassal states paying tribute to the New Kingdom of Egypt, whose administrative headquarters lay in Gaza.[70]'},
            {sender: false, time: '7:37 10.4.22', type: 'text', content: 'hi its my 2\'st message'},
        ],
        }
    }

users['example'] = {nickName: 'Example User', password: 'ex01', photo: A_photo,
    contacts: {
        'Shaul': [
            {sender: true, time: '7:34 10.3.22', type: 'text', content: 'I\'m looking for a musician, do you know one by any chance? my temper has been quite bad the last days..'},
            {sender: false, time: '7:37 10.3.22', type: 'text', content: 'There\'s one you should try, look for kingDavid in this app'},
            {sender: true, time: '7:39 10.3.22', type: 'text', content: 'What do you meen "king" David??? I\'m the king!!!'},
            ],
        'kingDavid': [
            {sender: false, time: '15:30 9.3.22', type: 'text', content: 'hi, gow are you?'},
            {sender: true, time: '16:48 9.3.22', type: 'text', content: 'you wouldn\'t believe it! I defeted that Plishty, 6 Amot tall!'},
            {sender: false, time: '16:49 9.3.22', type: 'text', content: 'wow! let\'s make you king then!'},
            ],
        'Shlomo': [
            {sender: true, time: '9:22 14.3.22', type: 'Image', content: beit_hmikdash},
            {sender: false, time: '9:32 14.3.22', type: 'text', content: 'that\'s nice! did you see what Hordus is going to build?'},
            {sender: false, time: '9:33 14.3.22', type: 'Image', content: bait_sheni},
            ],
        'Natan': [
            {sender: false, time: '15:30 9.3.22', type: 'text', content: 'hello :)'},
            ],
        'Shahar': [
            {sender: false, time: '8:32 10.4.22', type: 'text', content: 'hi :)'},
            {sender: false, time: '8:39 10.4.22', type: 'Video', content: snowVideo},
            {sender: true, time: '8:39 10.4.22', type: 'text', content: 'did you see are new exresize?'},
            {sender: true, time: '8:39 10.4.22', type: 'File', content: pdfFile, fileName: 'ex1PdfFile'},
            {sender: false, time: '8:50 10.4.22', type: 'Audio', content: record}
            ]
        }
    }
users['Shaul'] = {nickName: 'King Shaul', password: 'king0', photo: Me_photo,
    contacts: {
        'example': [
            {sender: false, time: '7:34 10.3.22', type: 'text', content: 'I\'m looking for a musician, do you know one by any chance? my temper has been quite bad the last days..'},
            {sender: true, time: '7:37 10.3.22', type: 'text', content: 'There\'s one you should try, look for kingDavid in this app'},
            {sender: false, time: '7:39 10.3.22', type: 'text', content: 'What do you meen "king" David??? I\'m the king!!!'},
            ]
        }
    }
users['kingDavid'] = {nickName: 'David HaMelech', password: 'king1', photo: crown_img,
    contacts: {
        'example': [
            {sender: true, time: '15:30 9.3.22', type: 'text', content: 'hi, gow are you?'},
            {sender: false, time: '16:48 9.3.22', type: 'text', content: 'you wouldn\'t believe it! I defeted that Plishty, 6 Amot tall!'},
            {sender: true, time: '16:49 9.3.22', type: 'text', content: 'wow! let\'s make you king then!'},
            ],
        }
    }
users['Shlomo'] = {nickName: 'King Shlomo', password: 'king2', photo: beit_hmikdash,
    contacts: {
        'example': [
            {sender: false, time: '9:22 14.3.22', type: 'Image', content: beit_hmikdash},
            {sender: true, time: '9:32 14.3.22', type: 'text', content: 'that\'s nice! did you see what Hordus is going to build?'},
            {sender: true, time: '9:33 14.3.22', type: 'Image', content: bait_sheni},
            ],
        }
    }
users['Natan'] = {nickName: 'Natan HaNavi', password: 'king2', photo: B_photo,
    contacts: {
        'example': [
            {sender: true, time: '15:30 9.3.22', type: 'text', content: 'hello :)'},
            ]
        }
    }
users['Shahar'] = {nickName: 'Shahar HaMelech!!!!11', password: 'sh12', photo: Shahar_photo,
    contacts: {
        'example': [
            {sender: true, time: '8:32 10.4.22', type: 'text', content: 'hi :)'},
            {sender: true, time: '8:39 10.4.22', type: 'Video', content: snowVideo},
            {sender: false, time: '8:39 10.4.22', type: 'text', content: 'did you see are new exresize?'},
            {sender: false, time: '8:39 10.4.22', type: 'File', content: pdfFile, fileName: 'ex1PdfFile'},
            {sender: true, time: '8:50 10.4.22', type: 'Audio', content: record}
            ]
        }
}
users['1'] = { nickMame: '1', password: '1', photo: contact, contacts: {}}


export async function FindUser(username){
    let ret = 0
    const requestOptions = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'accept': '*/*',
        },
        body: JSON.stringify({ id: username , pass: '0'})
    };
    await fetch('http://localhost:5180/api/login', requestOptions)
        .catch(err => setTimeout(() => console.clear())).then(response => ret = response.status);

    return ret == 400;
}

export async function VerifyPassword(username, pass) {
    let ret
    const requestOptions = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'accept': '*/*',
        },
        body: JSON.stringify({ id: username, pass: pass })
    };
    await fetch('http://localhost:5180/api/login', requestOptions)
        .then(response => ret = response.status).catch(err => setTimeout(() => console.clear()));

    return ret == 200;
}

export function GetPhoto(id) {
    return contact;
}

export async function GetContacts(username) {
    let contacts
    await fetch('http://localhost:5180/api/contacts/?user=' + username)
        .then((response) => { return response.json(); })
        .then((data) => contacts = data);

    return contacts;

    /*
    if (users[username] != null) {
        const retval = [];
        for (let con in users[username].contacts) {
            retval.push(con);
        }
        //console.log(retval);
        return retval;
    } else {
        return null;
    }
    */
   
}

export function GetNickName(id){
    if (users[id] != null) {
        return users[id].nickName;
    }
}

export async function GetChat(myId, contact){
    let chat
    await fetch('http://' + contact.server + '/api/contacts/' + contact.id + '/messages?user=' + myId)
        .then((response) => { return response.json(); })
        .then((data) => chat = data);
    return chat;
}

export async function AddContactToUser(user, newContact, nickname, contactServer){
    let ret;
    const requestOptions = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'accept': '*/*',
        },
        body: JSON.stringify({ id: newContact, name: nickname, server: contactServer })
    };
    await fetch('http://localhost:5180/api/contacts?user='+user, requestOptions)
        .then(response => ret = response.status);
    return ret == 201
}


export async function AddUser(userName, password, nickName, profImg) {
    let ret
    const requestOptions = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'accept': '*/*',
        },
        body: JSON.stringify({ id: userName, pass: password })
    };
    await fetch('http://localhost:5180/api/register', requestOptions)
        .then(response => ret = response.status);

    return ret == 200;
}

export async function SendMessage(fromUser, toContact, type, content) {

    const request1Options = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'accept': '*/*',
        },
        body: JSON.stringify({ from: fromUser, to: toContact.id , content: content})
    };
    await fetch('http://' + toContact.server + '/api/transfer', request1Options)
        

    const request2Options = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'accept': '*/*',
        },
        body: JSON.stringify({ content: content })
    };
    await fetch('http://localhost:5180/api/contacts/' + toContact.id + '/messages/?user=' + fromUser, request2Options)
      
}