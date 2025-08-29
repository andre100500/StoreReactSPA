const API_URL = "https://localhost:XXXX/api";

const getToken = () => localStorage.getItem("token");

// TODO: add method PATCH PUT DEPETE
// TODO: add error handling
// TODO: add generick types
export const api = (path: string) => {
  const url = `${API_URL}${path}`;

  const token = getToken();
  if (!token) {
    throw new Error("Unauthorize");
  }

  const headers = {
    Authorization: `Bearer ${token}`,
  };

  const succesHandler = (response) => response.json();

  return {
    get: () =>
      fetch(url, {
        method: "GET",
        headers,
      }).then(succesHandler),
    post: (object: any) =>
      fetch(url, {
        method: "POST",
        headers,
      }).then(succesHandler),
  };
};
