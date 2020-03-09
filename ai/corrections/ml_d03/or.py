import numpy as np
from mpl_toolkits.mplot3d import Axes3D
import matplotlib.pyplot as plt
from Neuron import *

entries = [[0, 0], [0, 1], [1, 0], [1, 1]]
n = Neuron(2)
n.weights[0] = -0.5
n.weights[1] = 1
n.weights[2] = 1

x = []
y = []
z = []
for ex in entries: # Copy entry values and out values in x y and z matrix
    x.append(ex[0])
    y.append(ex[1])
    n.activate(ex)
    z.append(n.out)

# Plot dots in 3D
fig = plt.figure()
ax = fig.add_subplot(111, projection='3d')
ax.scatter(x, y, z)
plt.show()
