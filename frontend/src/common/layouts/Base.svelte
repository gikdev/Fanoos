<script lang="ts">
  import type { SvelteHTMLElements } from "svelte/elements";
  import { base } from "./base";

  let { children, class: className = "", ...rest }: SvelteHTMLElements["div"] = $props();
</script>

<div class={base({ className: className?.toString() })} {...rest}>
  {@render children?.()}
</div>
