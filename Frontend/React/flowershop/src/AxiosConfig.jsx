import axios from 'axios';

const axiosInstance = axios.create({
  baseURL: 'https://localhost:7181/Order', 
  headers: { 'Content-Type': 'application/json' }
});

export async function getOrders(userId){
    try{
        const response = await axiosInstance.get(`/${userId}`); //https://localhost:7181/Order/2
        console.log(response.data); 
        return response.data;
      }
      catch(error){
        console.error('Error fetching orders:', error);
        throw error;
      }
};

export async function deleteOrder(orderId){
  try{
    const response = await axiosInstance.delete(`/${orderId}`); 
    return response.data;
  }catch(error){
    console.error('Error deleting order:', error)
  }
}


export default axiosInstance;