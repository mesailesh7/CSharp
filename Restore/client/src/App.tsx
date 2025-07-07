import { useEffect, useState } from "react";
import "./App.css";
import type { Product } from "./product";

function App() {
  const [products, setProducts] = useState<Product[]>([]);

  useEffect(() => {
    fetch("https://localhost:5001/api/products")
      .then((response) => response.json())
      .then((data) => setProducts(data));
  }, []);

const addProduct = () => {
  setProducts(prevState => [...products, {
    id: prevState.length + 1,
    name: 'product' + (prevState.length + 1), 
    price: (prevState.length * 100) + 100},
    quantityInStock:100,
    description: 'test',
    pictureUrl: 'https://pic.photo/200',
    type: 'test',
    brand: "test"
  
  
  ])
}


  return (
    <>
      <> 
        <h1>Re-store</h1>
        <ul>
          {products.map((item) => (
            <li>
              {item.name} - {item.price}{" "}
            </li>
          ))}
        </ul>
      </>
    </Produc>
  );
}
 
export default App;
