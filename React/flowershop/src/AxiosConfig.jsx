import axios from 'axios';

const axiosInstance = axios.create({
  baseURL: 'https://localhost:7181/Order', 
  headers: { 'Content-Type': 'application/json' }
});

export async function getOrders(userId){
    try{
        const response = await axiosInstance.get(`/${userId}`);
        return response.data;
      }
      catch(error){
        console.error('Error fetching orders:', error);
        throw error;
      }
};



export default axiosInstance;