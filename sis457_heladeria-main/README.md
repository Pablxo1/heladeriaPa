# sis457_heladeria
# 🍦 Heladería ICE

Bienvenido al repositorio oficial del sistema de gestión para la heladería **ICE**.  
Este proyecto tiene como objetivo digitalizar los procesos internos del negocio, permitiendo un mejor control de productos, ventas, clientes y personal.

## 🧊 Descripción del Negocio

La heladería **ICE** es un emprendimiento local dedicado a la venta de helados artesanales. Ofrecemos una variedad de sabores frutales y promociones para nuestros clientes.

## 🧩 Entidades del Sistema

### 🧁 producto ###
- `id_producto (PK)`
- `nombre`
- `precio`

### 👨‍🍳 empleado ###
- `id_empleado (PK)`
- `nombre`
- `apellido`
- `cargo`
- `fecha_contrataciòn`
- `teléfono`
- `direcciòn`

### usuario ###
- `id_usuario(PK)`
- `id_empleado(FK)`
- `usuario`
- `clave`

### 🚚 proveedor ###
- `id_proveedor (PK)`
- `nit`
- `teléfono`
- `tipo_producto`

### 🍓 sabor ###
- `id_sabor (PK)`
- `id_producto (FK)`
- `nombre`

### 👤 cliente ###
- `id_cliente (PK)`
- `ci`
- `drazon_social`
- `teléfono`

### 💰 venta ###
- `id_venta (PK)`
- `id_usuario (FK)`
- `id_cliente(FK)`
- `fecha`

### 📦 venta_detalle ###
- `id_detalle (PK)`
- `id_venta (FK)`
- `id_producto (FK)`
- `cantidad`
- `precio_unitario`
- `total`

### 🛒 pedido ###
- `id_pedido (PK)`
- `id_cliente (FK)`
- `id_empleado (FK)`
- `fecha_pedido`
- `tipo_pago`
- `estado`
