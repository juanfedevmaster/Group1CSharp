import React from 'react';
import { useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';

const Dashboard: React.FC = () => {
  const [activeTab, setActiveTab] = useState('');

  return (
    <div className="d-flex flex-column vh-100 w-100 p-0">
      <nav className="navbar navbar-expand-lg navbar-dark bg-primary w-100 px-4">
        <div className="container-fluid">
          <a className="navbar-brand" href="#">Farmacia TalentoTech</a>
          <button 
            className="navbar-toggler" 
            type="button" 
            data-bs-toggle="collapse" 
            data-bs-target="#navbarNavDropdown" 
            aria-controls="navbarNavDropdown" 
            aria-expanded="false" 
            aria-label="Toggle navigation"
          >
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="navbarNavDropdown">
            <ul className="navbar-nav">
              <li className="nav-item dropdown">
                <a 
                  className="nav-link dropdown-toggle" 
                  href="#" 
                  id="navbarDropdownMenuLink" 
                  role="button" 
                  data-bs-toggle="dropdown" 
                  aria-expanded="false"
                >
                  Presentación Productos
                </a>
                <ul className="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                  <li>
                    <a 
                      className="dropdown-item" 
                      href="#" 
                      onClick={() => setActiveTab('inyectables')}
                    >
                      Inyectables
                    </a>
                  </li>
                  <li>
                    <a 
                      className="dropdown-item" 
                      href="#" 
                      onClick={() => setActiveTab('tabletas')}
                    >
                      Tabletas
                    </a>
                  </li>
                  <li>
                    <a 
                      className="dropdown-item" 
                      href="#" 
                      onClick={() => setActiveTab('jarabes')}
                    >
                      Jarabes
                    </a>
                  </li>
                </ul>
              </li>
            </ul>
          </div>
        </div>
      </nav>

      <div className="container flex-grow-1 d-flex align-items-center justify-content-center">
        {activeTab === 'inyectables' && (
          <div className="text-center">
            <h2>Productos Inyectables</h2>
            {/* Aquí irá el contenido de productos inyectables */}
          </div>
        )}
        {activeTab === 'tabletas' && (
          <div className="text-center">
            <h2>Productos en Tabletas</h2>
            {/* Aquí irá el contenido de productos en tabletas */}
          </div>
        )}
        {activeTab === 'jarabes' && (
          <div className="text-center">
            <h2>Productos en Jarabe</h2>
            {/* Aquí irá el contenido de productos en jarabe */}
          </div>
        )}
        {!activeTab && (
          <div className="text-center">
            <h1 className="display-4">Bienvenido al Dashboard</h1>
            <p className="lead">Seleccione una categoría de productos del menú para ver su contenido.</p>
          </div>
        )}
      </div>
    </div>
  );
};

export default Dashboard;
