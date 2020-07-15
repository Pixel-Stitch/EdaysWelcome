function SetLanguageCodeCookie(code) {
    document.cookie = `languageCode=${code}; Secure`;
    location.reload(); 
}