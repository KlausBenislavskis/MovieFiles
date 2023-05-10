# Read environment variables
$dbServer = $env:MOVIE_DB_SERVER
$dbPort = $env:MOVIE_DB_PORT
$dbName = $env:MOVIE_DB_NAME
$dbUser = $env:MOVIE_DB_USER
$dbPass = $env:MOVIE_DB_PASS

# Replace placeholders in template file and generate database.json
(Get-Content database.json.template) -replace '\${DB_SERVER}', $dbServer `
                                        -replace '\${DB_PORT}', $dbPort `
                                        -replace '\${DB_NAME}', $dbName `
                                        -replace '\${DB_USER}', $dbUser `
                                        -replace '\${DB_PASS}', $dbPass |
Out-File -Encoding UTF8 database.json

# Run the linq2db scaffold command
dotnet linq2db scaffold -i database.json
