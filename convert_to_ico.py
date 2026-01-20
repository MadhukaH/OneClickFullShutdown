from PIL import Image
import sys

# Load PNG
img = Image.open('WinFormsShutdown/power_button.png')

# Create icon with multiple sizes
icon_sizes = [(16, 16), (32, 32), (48, 48), (64, 64), (128, 128), (256, 256)]

# Save as ICO
img.save('WinFormsShutdown/app_icon.ico', format='ICO', sizes=icon_sizes)

print("Icon created successfully!")
