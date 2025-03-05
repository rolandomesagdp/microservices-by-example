# FROM node:alpine
# WORKDIR /usr/src/app
# EXPOSE 4200

# COPY . /usr/src/app

# RUN npm install -g @angular/cli

# RUN npm install

# CMD ["ng", "serve", "--host", "0.0.0.0"]
FROM nginx:1.17.1-alpine
COPY nginx.conf /etc/nginx/nginx.conf
COPY ./dist/rolandomesa-ng/browser /usr/share/nginx/html
EXPOSE 80 443
ENTRYPOINT [ "nginx", "-g", "daemon off;" ]
