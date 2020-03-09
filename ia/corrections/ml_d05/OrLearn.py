from Neuron import *
from Dataset import *
from random import randint
import numpy as np
import matplotlib.pyplot as plt

trainSet = Dataset("Datasets/or.ds")
n = Neuron(len(trainSet.exemples[0].inputs))

# Matplitlib
fig = plt.gcf()
fig.show()
fig.canvas.draw()

x = []
y = []

i = 0
threshold = 0.1
loss = threshold
while loss >= threshold:
    for ex in trainSet.exemples:
        n.activate(ex.inputs)
        n.calculateOutputGradient(ex.outputs[0])
        n.applyGradient(0.01, ex.inputs)
    if i % 100 == 0:
        print("Iteration", i)
        loss = n.calcLoss(trainSet)
        x.append(i)
        y.append(loss)
        plt.clf() # Clear
        plt.plot(x, y) # Plot values
        fig.canvas.draw() # Draw curve
        print("Current loss:", loss)
    i += 1

print("Learned :")
for ex in trainSet.exemples:
    n.activate(ex.inputs)
    res = 0
    if (n.out >= 0.5):
        res = 1
    print(ex.inputs, ex.outputs, ":", res)

plt.show() # To keep the window open
