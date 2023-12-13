import { useState } from "react";
import { AnonymousForm } from "./AnonymousForm";
import { AuthForm } from "./AuthForm";
import { useTranslation } from 'react-i18next';
import * as Images from "../../Images/useImage";
import { LanguageSwitcher } from "../../Components/LanguageSwitcher";

export const Main = () => {
    const [isAuth, setIsAuth] = useState(false);

    const handleAnonymous = () => {
        setIsAuth(false);
    };
    
    const handleAuth = () => {
        setIsAuth(true);
    };

    const { t } = useTranslation();
    
    return (
        <div className="grid-container">
            <div className="grid-item1"> {/* grid up */}
                <LanguageSwitcher />
                <p>{t('greeting')}</p>
                <button className="Change-lang">
                    <img src={Images.Language} alt="Lang" />
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