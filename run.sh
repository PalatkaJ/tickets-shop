docker build -t simple-tickets-app . && \
docker run --rm -it \
  -v "$(pwd)":/tickets-shop \
  -v /tickets-shop/bin \
  -v /tickets-shop/obj \
  simple-tickets-app
