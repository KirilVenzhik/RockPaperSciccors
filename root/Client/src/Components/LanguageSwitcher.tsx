import { useTranslation } from 'react-i18next';

export const LanguageSwitcher = () => {
  const { i18n } = useTranslation();

  /* const availableLanguages = ['en', 'ua'];
  const currentLanguageIndex = availableLanguages.indexOf(i18n.language);
  сделать одной кнопкой, уже начала */

  const changeLanguage = (lng: string) => {
    i18n.changeLanguage(lng);
  };

  return (
    <div>
      <button onClick={() => changeLanguage('en')}>English</button>
      <button onClick={() => changeLanguage('ua')}>Ukrainian</button>
    </div>
  );
};
