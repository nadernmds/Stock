import decode from "jwt-decode";
export default class Api {
  constructor() {
    this.get.bind(this);
    this.post.bind(this);
    this.put.bind(this);
    this.delete.bind(this);
    this.getUserId.bind(this);
  }
  tokenName = "asdfkjlsdjflasjfodkljaghsjguyugjgjhgkjasdghjgjfjdkgfjhdgfdfjh";
  _getToken = () => {
    // Retrieves the user token from localStorage
    return localStorage.getItem(this.tokenName);
  };
  getUserId() {
    const decoded = decode(this._getToken());
    return decoded[
      "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"
    ];
  }
  get(url, options) {
    options = {
      ...options,
      headers: {
        "Content-Type": "application/json",
        Authorization: "Bearer " + this._getToken()
      }
    };
    console.log(options);
    return fetch(url, options);
  }
  post(url, options) {
    options = {
      ...options,
      headers: {
        "Content-Type": "application/json",
        Authorization: "Bearer " + this._getToken()
      }
    };
    return fetch(url, options);
  }
  put(url, options) {
    options = {
      ...options,
      headers: {
        "Content-Type": "application/json",
        Authorization: "Bearer " + this._getToken()
      }
    };
    return fetch(url, options);
  }
  delete(url, options) {
    options = {
      ...options,
      headers: {
        "Content-Type": "application/json",
        Authorization: "Bearer " + this._getToken()
      }
    };
    return fetch(url, options);
  }
}
