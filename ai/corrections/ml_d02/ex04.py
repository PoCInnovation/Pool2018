import operator
from ex02 import *

def getNearestNeighbors(example, dataset, k):
    neighbors = []
    for i in range(0, len(dataset.exemples)):
        dist = computeDistance(example, dataset.exemples[i])
        neighbors.append((dist, dataset.exemples[i]))
    neighbors.sort(key=operator.itemgetter(0))
    k_nearest_neighbors = []
    for i in range(0, k):
        k_nearest_neighbors.append(neighbors[i][1])
    return k_nearest_neighbors
