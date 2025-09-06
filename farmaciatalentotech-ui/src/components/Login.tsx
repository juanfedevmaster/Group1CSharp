import React, { useState } from 'react';

interface LoginProps {
  onLoginSuccess: () => void;
}

const Login: React.FC<LoginProps> = ({ onLoginSuccess }) => {
  const [nombreUsuario, setNombreUsuario] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError('');

    try {
      const response = await fetch('http://localhost:5007/User/api/Auth', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ nombreUsuario, password }),
      });

      if (!response.ok) {
        throw new Error('Credenciales incorrectas');
      }

      const data = await response.json();
      console.log('Login exitoso:', data);
      // Aquí puedes guardar el token o manejar la respuesta
      onLoginSuccess();
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Error al iniciar sesión');
    }
  };

  return (
    <form className="p-4 border rounded shadow-sm bg-white" style={{ maxWidth: 400, margin: 'auto', marginTop: 50 }} onSubmit={handleSubmit}>
      <h2 className="mb-3">Iniciar Sesión</h2>
      <div className="mb-3">
        <label className="form-label">Usuario:</label>
        <input
          type="text"
          className="form-control"
          value={nombreUsuario}
          onChange={e => setNombreUsuario(e.target.value)}
          required
        />
      </div>
      <div className="mb-3">
        <label className="form-label">Contraseña:</label>
        <input
          type="password"
          className="form-control"
          value={password}
          onChange={e => setPassword(e.target.value)}
          required
        />
      </div>
      <button type="submit" className="btn btn-primary w-100">Entrar</button>
      {error && <div className="alert alert-danger mt-3">{error}</div>}
    </form>
  );
};

export default Login;