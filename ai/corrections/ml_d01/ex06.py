import numpy as np
from mpl_toolkits.mplot3d import Axes3D
import matplotlib.pyplot as plt
from Dataset import *

dataset = Dataset("xor.ds") # Load Dataset

x = []
y = []
z = []
for ex in dataset.exemples: # Copy entry values and out values in x y and z matrix
    x.append(ex.inputs[0])
    y.append(ex.inputs[1])
    z.append(ex.outputs[0])

# Plot dots in 3D
fig = plt.figure()
ax = fig.add_subplot(111, projection='3d')
ax.scatter(x, y, z)
plt.xlim(-0.5, 1.5)
plt.ylim(-0.5, 1.5)
plt.show()
