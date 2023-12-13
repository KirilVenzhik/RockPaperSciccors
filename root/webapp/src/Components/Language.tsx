import i18n from 'i18next';
import { initReactI18next } from 'react-i18next';

const resources = {
  en: {
    translation: {
      'Welcome': 'Welcome',
      greeting: 'Hello!',
    },
  },

  ua: {
    translation: {
      greeting: 'Priv'
    },
  },
};

i18n.use(initReactI18next).init({
    resources,
    lng: 'en', // Язык по умолчанию
    fallbackLng: 'ua', //Используется в случае, если ресурс для текущего языка не будет найден
    interpolation: {
      escapeValue: false,
    },
  });

export default i18n;
