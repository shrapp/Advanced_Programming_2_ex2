import React, { useRef, useState } from "react";
import { FindUser, VerifyPassword } from "../data/users";
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';

// this is only a basic screen, to see things can work
function Login({setUser, setRegister}) {

    const usernameTextBox = useRef(null)
    const passwordTextBox = useRef(null)
    const [errors, setErrors] = useState([])
    const [connection, setConnection] = useState()

    const joinHub = async (user) => {
        try {
            const connection = new HubConnectionBuilder()
                .withUrl("http://localhost:5180/login")
                .configureLogging(LogLevel.Information)
                .build();
            /*
            connection.on("ReceiveMessage", (user, message) => {
                setMessages(messages => [...messages, { user, message }]);
            });

            connection.on("UsersInRoom", (users) => {
                setUsers(users);
            });

            connection.onclose(e => {
                setConnection();
                setMessages([]);
                setUsers([]);
            });
            */

            await connection.start();
            
            setConnection(connection);
        } catch (e) {
            console.log(e);
        }
    }




    const login = async function(e){
        e.preventDefault();
        let tempErr = [];
        const userName = usernameTextBox.current.value;


 
        if (await FindUser(userName)){
            if (await VerifyPassword(userName, passwordTextBox.current.value)) {
                setUser(userName);
                joinHub(userName);
            }
            else
                tempErr.push('wrong password')
        } else {
            tempErr.push('no such user')
        }
        setErrors(tempErr);

        //console.log

        //setUser('example');
    }

    const registerButton = function(){setRegister(true);}

    return(
         <div className="login">
        <form >
            <div className="mb-3">
                <label className="form-label">User Name</label>
                <input ref={usernameTextBox} type="username" className="form-control"></input>
            </div>
            <div className="mb-3">
            <label className="form-label">Password</label>
            <input ref={passwordTextBox} type="password" className="form-control" id="exampleInputPassword1"></input>
            </div>
            <div className="mb-3 err_alert" style={errors ? {display: "flex"} : {display: "none"}}>
                {errors}
            </div>
            <button type="submit" onClick={login} className="btn btn-primary" data-toggle="collapse">Login</button>
            <div>
                don't have a user yet?
                <span className="linkFont" onClick={registerButton}> register now! </span>
            </div>
        </form>
        </div>
        )
        /*<form className="d-flex">
            <input ref={textBox} className="form-control me-2" placeholder="Type User Name" ></input>
            <button onClick={click} type="submit">login</button>
        </form>*/
        
    }

export default Login;