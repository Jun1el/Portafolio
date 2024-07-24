# Usar la imagen oficial de Nginx como base
FROM nginx:latest
# Path: /usr/share/nginx/html
# Copiar archivos de tu portafolio al directorio predeterminado de Nginx
COPY /misitio /usr/share/nginx/html
