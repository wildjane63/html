
# 全局配置 
mixed-port: 7890
allow-lan: true
bind-address: "*"
ipv6: false
unified-delay: true
tcp-concurrent: true
log-level: warning
global-client-fingerprint: chrome
keep-alive-idle: 600
keep-alive-interval: 15
profile:
  store-selected: true
  store-fake-ip: true

# 为防止使用插件朋友遇到面板问题，我注释掉了此模块。
#external-controller: 0.0.0.0:9090
#secret: ""
#external-ui: ui
#external-ui-name: zashboard
#external-ui-url: "https://github.com/Zephyruso/zashboard/archive/refs/heads/gh-pages.zip"

# 嗅探（fakeip下其实可以不用嗅探）
sniffer:
  enable: true
  sniff:
    HTTP:
      ports: [80, 8080-8880]
      override-destination: true
    TLS:
      ports: [443, 8443]
    QUIC:
      ports: [443, 8443]
  skip-domain:
    - "Mijia Cloud"
    - "+.push.apple.com"

# 入站
tun:
  enable: true
  # system/gvisor/mixed
  stack: mixed
  dns-hijack: ["any:53", "tcp://any:53"]
  #使用nikki，混入全部不修改的情况，开启接口指定为nikki
  #device: nikki
  #使用仅内核自行修改下面三项为true
  auto-route: false
  auto-redirect: false
  auto-detect-interface: false

# DNS模块
dns:
  enable: true
  cache-algorithm: arc
  listen: 0.0.0.0:1053
  ipv6: false
  respect-rules: true
  enhanced-mode: fake-ip
  fake-ip-range: 28.0.0.1/8
  fake-ip-filter-mode: blacklist
  fake-ip-filter:
    - "rule-set:fakeipfilter_domain"
  default-nameserver:
    - https://223.5.5.5/dns-query
  proxy-server-nameserver:
    - https://dns.alidns.com/dns-query
    - https://doh.pub/dns-query
  nameserver:
    - https://dns.alidns.com/dns-query
    - https://doh.pub/dns-query
