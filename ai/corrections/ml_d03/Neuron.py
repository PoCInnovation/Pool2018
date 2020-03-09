import random
import numpy as np

def logistic(x):
    return 1. / (1. + np.exp(-x))

class Neuron:
    def __init__(self, nbEntry):
        self.weights = [random.uniform(-2, 2) for _ in range(nbEntry + 1)]
        self.out = 0.

    def activate(self, entries):
        sum = self.weights[0]
        for i in range(1, len(self.weights)):
            sum += self.weights[i] * entries[i - 1]
        self.out = logistic(sum)

    # For Ex04
    def activateWithLayer(self, prevLayer):
        sum = self.weights[0]
        for i in range(1, len(self.weights)):
            sum += self.weights[i] * prevLayer[i - 1].out
        self.out = logistic(sum)
