import React, { useState } from 'react'
import { useNavigate } from 'react-router-dom'
import authService from './api-authorization/AuthorizeService'

export default function LoginForm() {
    let navigate = useNavigate();
    const [canRender, setCanRender] = useState(true)

    const tryLogin = (iframe) => {
        // authService.completeSignIn
        console.log(iframe);
        iframe.target.contentWindow.onunload = () => {
            navigate('/authentication/login');
            setCanRender(false);
        }

    }
    return (
        // <form>
        //     <label htmlFor="email">Email:</label>
        //     <input type="email" name="email" placeholder='name@domain.com' autoComplete='username' required />
        //     <label htmlFor="passwd">Password:</label>
        //     <input type="password" name="passwd" autoComplete='current-password' placeholder='password' required />
        //     <input type="button" value="SignIn" onClick={tryLogin} />
        // </form>
        <>
            {canRender && <iframe src="https://localhost:44405/Identity/Account/Login" frameborder="0" style={{ height: 'inherit', overflow: 'hidden' }} onLoad={tryLogin} />}
        </>
    )
}
