#!/bin/bash

# Replace placeholders in template file and generate database.json
sed -e "s/\${DB_SERVER}/$MOVIE_DB_SERVER/g" -e "s/\${DB_PORT}/$MOVIE_DB_PORT/g" -e "s/\${DB_NAME}/$MOVIE_DB_NAME/g" -e "s/\${DB_USER}/$MOVIE_DB_USER/g" -e "s/\${DB_PASS}/$MOVIE_DB_PASS/g" database.json.template > database.json

dotnet linq2db scaffold -i database.json