import numpy as np
from mpl_toolkits.mplot3d import Axes3D
import matplotlib.pyplot as plt
from NeuralNetwork import *

entries = [[0, 0], [0, 1], [1, 0], [1, 1]]
n = NeuralNetwork([2, 2, 1])

# First neuron of hidden layer
n.layers[1][0].weights[0] = -0.5
n.layers[1][0].weights[1] = -1
n.layers[1][0].weights[2] = 1

# Second neuron of hidden layer
n.layers[1][1].weights[0] = -0.5
n.layers[1][1].weights[1] = 1
n.layers[1][1].weights[2] = -1

# Ouput neuron
n.layers[2][0].weights[0] = -0.8
n.layers[2][0].weights[1] = 1
n.layers[2][0].weights[2] = 1

x = []
y = []
z = []
for ex in entries: # Copy entry values and out values in x y and z matrix
    x.append(ex[0])
    y.append(ex[1])
    n.activate(ex)
    z.append(n.getOutputs()[0])

# Plot dots in 3D
fig = plt.figure()
ax = fig.add_subplot(111, projection='3d')
ax.scatter(x, y, z)
plt.show()
