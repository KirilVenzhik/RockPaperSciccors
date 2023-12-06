import { useState } from "react";
import { AnonymousForm } from "./AnonymousForm";
import { AuthForm } from "./AuthForm";

export const Main = () => {
    const [isAuth, setIsAuth] = useState(false);

    const handleAnonymous = () => {
        setIsAuth(false);
    };
    
    const handleAuth = () => {
        setIsAuth(true);
    };
    
    return (
        <div className="grid-container">
            <div className="grid-item1"> {/* grid up */}
                <button className="Change-lang">
                    <img src="lang-logo.jpg" alt="Lang" />
                    UKR
                </button>
                <div className="Logo-name">
                    <img src="logo.jpg" alt="Logo" />
                    <p>Rock Paper Scissors</p>
                </div> 
            </div>
            
            <div className="grid-item2"> {/* grid bottom */}
                <div className="auth-window"> {/* auth window */}
                    <div>
                        <button onClick={handleAnonymous}>Anonym-page</button>
                        <button onClick={handleAuth}>auth-page</button>
                    </div>

                    {isAuth ? <AuthForm /> : <AnonymousForm />}
                    
                    <button>Start</button> 
                </div>

                <div className="rules-window"> {/* rules window */}
                    <h4>rules</h4>
                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Lorem ipsum dolor sit amet consectetur adipisicing elit.</p>
                </div>
            </div>
        </div>
    );
};