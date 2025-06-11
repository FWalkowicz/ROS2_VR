import sys
if sys.prefix == '/usr':
    sys.real_prefix = sys.prefix
    sys.prefix = sys.exec_prefix = '/home/walkowiczf/MoveoUnity/MoveoROS2/install/ros_tcp_endpoint'
