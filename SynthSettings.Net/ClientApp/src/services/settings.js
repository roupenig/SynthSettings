import axios from "axios";

const baseUrl = `https://localhost:7008/setting`;

const getAll = async () => {
  const response = await axios.get(baseUrl);
  return response.data;
};

const getConfig = async (id) => {
  const response = await axios.get(`${baseUrl}/${id}`);
  return response.data;
};

const create = async (object) => {
  const response = await axios.post(baseUrl, object);
  return response.data;
};

const update = async (object) => {
  const response = await axios.put(`${baseUrl}/${object.id}`, object);
  return response.data;
};

const remove = async (id) => {
  const response = await axios.delete(`${baseUrl}/${id}`);
  return response.data;
};

export default {
  getAll,
  getConfig,
  create,
  update,
  remove,
};
