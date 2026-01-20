Add-Type -AssemblyName System.Drawing

$pngPath = "d:/GitHub_Project/OneClickFullShutdown/WinFormsShutdown/power_button.png"
$icoPath = "d:/GitHub_Project/OneClickFullShutdown/WinFormsShutdown/app_icon.ico"

# Load the PNG image
$img = [System.Drawing.Image]::FromFile($pngPath)

# Create a bitmap from the image
$bitmap = New-Object System.Drawing.Bitmap $img

# Create icon sizes (16x16, 32x32, 48x48, 256x256)
$sizes = @(16, 32, 48, 256)
$memoryStream = New-Object System.IO.MemoryStream

# ICO header
$memoryStream.WriteByte(0) # Reserved
$memoryStream.WriteByte(0) # Reserved
$memoryStream.WriteByte(1) # Type (1 = ICO)
$memoryStream.WriteByte(0) # Type
$memoryStream.WriteByte($sizes.Count) # Number of images
$memoryStream.WriteByte(0) # Number of images

$imageStreams = @()

foreach ($size in $sizes) {
    # Resize bitmap
    $resized = New-Object System.Drawing.Bitmap $size, $size
    $graphics = [System.Drawing.Graphics]::FromImage($resized)
    $graphics.InterpolationMode = [System.Drawing.Drawing2D.InterpolationMode]::HighQualityBicubic
    $graphics.DrawImage($bitmap, 0, 0, $size, $size)
    $graphics.Dispose()
    
    # Save to stream as PNG
    $pngStream = New-Object System.IO.MemoryStream
    $resized.Save($pngStream, [System.Drawing.Imaging.ImageFormat]::Png)
    $pngBytes = $pngStream.ToArray()
    $imageStreams += $pngBytes
    
    # Write directory entry
    $memoryStream.WriteByte($size) # Width
    $memoryStream.WriteByte($size) # Height
    $memoryStream.WriteByte(0) # Color palette
    $memoryStream.WriteByte(0) # Reserved
    $memoryStream.WriteByte(1) # Color planes
    $memoryStream.WriteByte(0) # Color planes
    $memoryStream.WriteByte(32) # Bits per pixel
    $memoryStream.WriteByte(0) # Bits per pixel
    
    # Size of image data
    $sizeBytes = [System.BitConverter]::GetBytes([int]$pngBytes.Length)
    $memoryStream.Write($sizeBytes, 0, 4)
    
    $resized.Dispose()
    $pngStream.Dispose()
}

# Calculate and write offsets
$offset = 6 + ($sizes.Count * 16)
foreach ($imageData in $imageStreams) {
    $memoryStream.Seek(6 + ($imageStreams.IndexOf($imageData) * 16) + 12, [System.IO.SeekOrigin]::Begin) | Out-Null
    $offsetBytes = [System.BitConverter]::GetBytes([int]$offset)
    $memoryStream.Write($offsetBytes, 0, 4)
    $offset += $imageData.Length
}

# Write image data
$memoryStream.Seek(0, [System.IO.SeekOrigin]::End) | Out-Null
foreach ($imageData in $imageStreams) {
    $memoryStream.Write($imageData, 0, $imageData.Length)
}

# Save to file
$bytes = $memoryStream.ToArray()
[System.IO.File]::WriteAllBytes($icoPath, $bytes)

$memoryStream.Dispose()
$bitmap.Dispose()
$img.Dispose()

Write-Host "Icon created successfully: $icoPath"
