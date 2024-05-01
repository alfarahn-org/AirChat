Script to run the windows worker:

# Stop the service
Stop-Service -Name 'AirChat.WindowsWorker' -ErrorAction SilentlyContinue
Write-Output "Service stopped."

# Delete the service
sc.exe delete 'AirChat.WindowsWorker'
Write-Output "Service deleted."

# Create the service
# Remember to use your path for the worker
New-Service -Name 'AirChat.WindowsWorker' -BinaryPathName 'C:\repos\AirChat\AirChat.WindowsWorker\bin\Debug\net8.0\AirChat.WindowsWorker.exe' -DisplayName 'AirChat Windows Worker'
Write-Output "Service created."

# Start the service
Start-Service -Name 'AirChat.WindowsWorker'
Write-Output "Service started."
