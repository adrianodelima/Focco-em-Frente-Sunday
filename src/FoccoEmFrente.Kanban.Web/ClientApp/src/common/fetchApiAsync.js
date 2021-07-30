export default async function fetchApiAsync({route, data, method, auth}) {
  const response = await fetch(`${route}`, {
     method: `${method}`,
     headers: {
        "Content-Type": "application/json",
         Accept: "application/json",
         Authorization: auth ? `Bearer ${auth}` : null
     },
     body: data ? JSON.stringify(data) : null
  });

  return response;
}