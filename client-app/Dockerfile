# Используем официальный образ Nginx как базовый
FROM nginx:alpine

# Копируем статические файлы из папки dist в папку, откуда Nginx будет их раздавать
COPY dist/ /usr/share/nginx/html
# COPY nginxConf/default.conf /etc/nginx/default.conf

# Конфигурация Nginx уже настроена для обслуживания статических файлов
# и прослушивания порта 80, так что дополнительные настройки не требуются
# Создаем файл конфигурации Nginx


# Контейнер будет слушать порт 80
EXPOSE 80

# Запуск Nginx при старте контейнера
CMD ["nginx", "-g", "daemon off;"]
