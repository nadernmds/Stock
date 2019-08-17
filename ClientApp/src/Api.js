import decode from "jwt-decode";
import PersianDate from "persian-date";
export default class Api {
  constructor() {
    this.get.bind(this);
    this.post.bind(this);
    this.put.bind(this);
    this.delete.bind(this);
    this.getUserId.bind(this);
    this.toPersainDate.bind(this);
    this.toMiladiDate.bind(this);
  }
  tokenName = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9";
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
  toPersainDate(miladi) {
    const a = new Date(miladi);
    let persianDate = new PersianDate(a);
    // persianDate.toCalendar('persian');
    return persianDate.format("YYYY-MM-DD");
  }
  toMiladiDate(shamsi) {
    console.log(shamsi);
    if (shamsi.length == 10) {
      var d = new Date(shamsi);
      let persianDate = new PersianDate([
        d.getFullYear(),
        d.getMonth() + 1,
        d.getDate()
      ]).toCalendar("gregorian").toLocale('en');
      return persianDate.format("YYYY-MM-DD");
    }
  }

  get(url, options) {
    options = {
      ...options,
      headers: {
        "Content-Type": "application/json",
        Authorization: "Bearer " + this._getToken()
      }
    };
    return fetch(url, options);
  }
  post(url, options) {
    options = {
      ...options,
      method: "post",
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
      method: "put",
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
      method: "delete",
      headers: {
        "Content-Type": "application/json",
        Authorization: "Bearer " + this._getToken()
      }
    };
    return fetch(url, options);
  }
}
