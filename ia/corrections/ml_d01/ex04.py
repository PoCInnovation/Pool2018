import numpy as np
import matplotlib.pyplot as plt

x = np.linspace(-5, 3, 30)
y = 1 + np.exp(-x)
plt.xlim(-5, 3)
plt.plot(x, y)
plt.show()
